namespace VemDoBem.Domain.Entidades.Builders
{
    public class TipoTrabalhoBuilder
    {
        private string _descricao = "Tipo trabalho novo";
        private bool _ativo = true;

        public TipoTrabalho Construir()
        {
            return new TipoTrabalho(_descricao);
        }
    }
}
