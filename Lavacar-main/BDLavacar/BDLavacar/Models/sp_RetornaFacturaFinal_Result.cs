//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BDLavacar.Models
{
    using System;
    
    public partial class sp_RetornaFacturaFinal_Result
    {
        public string Nombre_Completo { get; set; }
        public int Id_Cliente_P { get; set; }
        public string Cedula_P { get; set; }
        public string Genero_P { get; set; }
        public string Fecha_Nacimiento_P { get; set; }
        public string Nombre_P { get; set; }
        public string PApellido { get; set; }
        public string SApellido { get; set; }
        public string Correo_P { get; set; }
        public int Id_Provincia_P { get; set; }
        public int Id_Canton_P { get; set; }
        public int Id_Tipo_P { get; set; }
        public int Id_Distrito_P { get; set; }
        public int Id_Factura_F { get; set; }
        public int Id_Vehiculo_F { get; set; }
        public int Id_Persona_F { get; set; }
        public Nullable<int> Total_F { get; set; }
        public string Fecha_F { get; set; }
        public int Id_Vehiculo_V { get; set; }
        public string Placa_V { get; set; }
        public int Id_Marca_V { get; set; }
        public int Id_Tipo_V { get; set; }
        public int Numero_Puertas_V { get; set; }
        public int Numero_Ruedas_V { get; set; }
        public int Id_Marca_MV { get; set; }
        public string Codigo_MV { get; set; }
        public string Tipo_MV { get; set; }
        public int Id_Pais_MV { get; set; }
    }
}
