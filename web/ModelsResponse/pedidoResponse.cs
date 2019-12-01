using System;
using System.Collections.Generic;

namespace web.ModelsResponse
{
    public class pedidoResponse
    {
        public float total { get; set; }

        public List<itemOrders> itemOrders { get; set; }

        public List<itemDrinks> itemDrinks { get; set; }

        public string pagamento { get; set; }

        public restaurante restaurante { get; set; }

        public DateTime data { get; set; }
    }

    public class itemOrders
    {
        public string desc { get; set; }

        public int amount { get; set; }

        public string type { get; set; }

        public int id { get; set; }

        public float value { get; set; }

        public string size { get; set; }
    }

    public class itemDrinks
    {
        public string drinkDetails { get; set; }

        public string drinkSize { get; set; }

        public string drinkName { get; set; }

        public int amount { get; set; }

        public float value { get; set; }

        public int id { get; set; }
    }

    public class restaurante
    {
        public string name { get; set; }

        public string address { get; set; }

        public int id { get; set; }
    }

    // TESTE
    public static class testJson
    {
        public static string json
        {
            get
            {
                return "{'total':67.5,'itemOrders':[{'desc':'oregano, parmesao, catupiry e mussarela','amount':1,'type':'mussarela','id':3,'value':20.5,'size':'pequena'},{'desc':'oregano, parmesao, catupiry e mussarela','amount':1,'type':'mussarela','id':1,'value':37.5,'size':'grande'}],'itemDrinks':[{'drinkDetails':'tradicional','drinkSize':'2 litros','drinkName':'coca-cola','amount':1,'value':9.5,'id':8}],'pagamento':'cartao','restaurante':{'name':'Bar do Tina','address':'Rua Teste dos testes','id':1},'data':'2019-11-28 00:39:39'}";
            }
        }
    }

}