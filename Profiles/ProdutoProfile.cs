using AutoMapper;
using Projeto_Ascii.Dtos;
using Projeto_Ascii.Models;

namespace Projeto_Ascii.Profiles;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<CriarProdutoDto, Produto>();
        CreateMap<Produto, LerProdutoDto>();
        CreateMap<AtualizarProdutoDto, Produto>();
    }
}