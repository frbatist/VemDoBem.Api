param (
    [String]$assembly_filter
)

$DebugPreference = "Continue"

Write-Host("##[debug] Assembly Filters: $($assembly_filter.Count) - $assembly_filter")

[String]$InputFile = (Get-ChildItem  -Filter "coverage.cobertura.xml" -Recurse).FullName
Write-Debug("InputFile: "+$InputFile)
[String]$OutputFile = "$env:Build_SourcesDirectory\filtred.coverage.cobertura.xml"
Write-Debug("OutputFile: "+$OutputFile)

# Load the existing document
$Doc = [xml](Get-Content $InputFile)

# Specify tag names to delete and then find 
$filter = $assembly_filter
if("empty" -ne $filter){
#$DeleteNames = ($filter).split(",")
$DeleteNames = $filter.split(" ")


($doc.coverage.packages.package |Where-Object { $DeleteNames -contains $_.Name }) | ForEach-Object {
    # Remove each node from its parent
    Write-Host("##[debug] Removing $($_.Name) results")
    [void]$_.ParentNode.RemoveChild($_)
    }
}

function Get-LineSummary {
    param (
        [xml]$file
    )
    [int]$uncovered = 0
    [int]$covered = 0
    [int]$total = 0

    foreach($package in $file.coverage.packages.package){
        foreach($class in $package.classes.class){
            foreach($line in $class.lines.line){ 
            if($line.hits -eq 0){
                $uncovered++
            }else{
                $covered++
            }
            $total++
            }
        }
    }
    $Global:line = [PsCustomObject]@{covered = $covered;
        uncovered = $uncovered;
        total = $total
    }
    return $Global:line
}

$lineSummary = Get-LineSummary -file $Doc

function Get-CoveredPercent {
    param (
        $lineSummary
    )
    $coveredPercent = $($lineSummary.covered)/$($lineSummary.total);
    return $coveredPercent
}

function Set-XmlHeaderLineCoverageValue {
    param(
        [Parameter(Mandatory = $True)]
        [System.Object]$lineSummary,

        [Parameter(Mandatory = $True)]
        [xml]$file
    )
    $coveredPercent = Get-CoveredPercent -lineSummary $lineSummary
    $roundedCoveredPercent = [math]::Round($coveredPercent,3)
    $file.coverage."line-rate" = ($roundedCoveredPercent).ToString()
    $file.coverage."lines-covered" = ($lineSummary.covered).ToString()
    $file.coverage."lines-valid" = ($lineSummary.total).ToString()
    Write-Host("##vso[task.setvariable variable=current.codecoverage;] $roundedCoveredPercent")
}

Set-XmlHeaderLineCoverageValue $lineSummary $Doc

# Save the modified document
$Doc.Save($OutputFile)