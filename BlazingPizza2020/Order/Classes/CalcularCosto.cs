using System;
using System.Collections.Generic;

namespace BlazingPizza2020.Order.Classes
{
    public class CalcularCosto
    {   
        public int costoTotal { get; set; }
        List<Pizza> PedidoLista = new List<Pizza>();
        public  void setPedidoLista(List<Pizza> PedidoLista){
            this.PedidoLista = PedidoLista;
        }
        public  void CalcularCostoPedido(){
            int count = 1;
            int costoUni = 0;
            Console.WriteLine("========================== Calculando Costo: =======================");
            foreach (Pizza pedido in this.PedidoLista)
            {
                Console.Write("costo pizza "+count+": ");
                costoTotal +=pedido.tamanio.costo;
                costoUni +=pedido.tamanio.costo;
                for (int i = 0; i < pedido.coberturas.Count; i++)
                {
                    costoTotal +=pedido.coberturas[i].pizza.costo;
                    costoUni +=pedido.coberturas[i].pizza.costo;
                }
                Console.WriteLine(costoUni);
                costoUni = 0;
                count++;
            }
            Console.WriteLine("Costo Total: "+costoTotal);
        }
    }
}