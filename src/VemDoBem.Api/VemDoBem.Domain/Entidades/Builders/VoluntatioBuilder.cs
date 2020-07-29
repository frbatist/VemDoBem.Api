using System.Collections.Generic;
using VemDoBem.Domain.Dtos;

namespace VemDoBem.Domain.Entidades.Builders
{
    public class VoluntatioBuilder
    {
        private long _idUsuario = 10;
        private int _idInstituicao = 1;        
        private List<TipoTrabalho> _preferenciasDeTrabalho = new List<TipoTrabalho>
        {
            new TipoTrabalhoBuilder().Construir()
        };

        public VoluntatioBuilder ComUsuario(long idUsuario)
        {
            _idUsuario = idUsuario;
            return this;
        }

        public VoluntatioBuilder ComInstituicao(int idInstituicao)
        {
            _idInstituicao = idInstituicao;
            return this;
        }
        public VoluntatioBuilder ComPreferenciasDeTrabalho(List<TipoTrabalho> tipoTrabalhos)
        {
            _preferenciasDeTrabalho = tipoTrabalhos;
            return this;
        }

        public VoluntarioDto ConstruirDto()
        {
            return new VoluntarioDto
            {
                IdUsuario = _idUsuario,
                IdInstituicao = _idInstituicao,
                PreferenciasDeTrabalho = _preferenciasDeTrabalho
            };
        }

        public Voluntario Construir()
        {
            return new Voluntario(ConstruirDto());
        }
    }
}
