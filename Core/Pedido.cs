using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core;

public class Pedido
{
    public int Id { get; set; }
    public Usuario? Usuario { get; set; }
    public DateTime? DataCriacao { get; set; }

    public Pedido(int id, Usuario? usuario, DateTime? dataCriacao)
    {
        Id = id;
        Usuario = usuario;
        DataCriacao = dataCriacao;
    }
    override public string ToString()
    {
        return $"Id: {Id}, Usuario: {Usuario}, DataCriacao: {DataCriacao}";
    }
}
