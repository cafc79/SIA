using System;

public class DataProducccion
{
    public datos Data()
    {
        return new datos
                   {
                       id = 1,
                       Reg_Int = "51921602-00000054",
                       Lote = "1S5192160200000054",
                       CantidadLote = 30,
                       Holgura = 5,
                       NoParte = "62110-T5RA-A200-H1",
                       NoPedido = "112131234512355",
                       CantidadPedido = 30
                   };
    }

    public fases Fase1()
    {
        return new fases
                   {
                       id = 1,
                       fase = 1,
                       Recepcion = new DateTime(2013, 07, 01),
                       Inicio = DateTime.Today,
                       Entrega = DateTime.Today,
                       CantidadRecibida = 9999,
                       Recibe = "Jesús C. Barrera Gonzalez"
                   };
    }

    public fases Fase2()
    {
        return new fases
                   {
                       id = 1,
                       fase = 2,
                       Recepcion = DateTime.Today,
                       Inicio = DateTime.Today,
                       Entrega = DateTime.Today,
                       CantidadRecibida = 9998,
                       Recibe = "Jesús C. Barrera Gonzalez"
                   };
    }

    public class datos
    {
        public int id { get; set; }
        public string Reg_Int { get; set; }
        public string Lote { get; set; }
        public double CantidadLote { get; set; }
        public int Holgura { get; set; }
        public string NoParte { get; set; }
        public string NoPedido { get; set; }
        public int CantidadPedido { get; set; }
    }

    public class fases
    {
        public int id { get; set; }
        public int fase { get; set; }
        public DateTime Recepcion { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Entrega { get; set; }
        public int CantidadRecibida { get; set; }
        public string Recibe { get; set; }
    }
}