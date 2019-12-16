
using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMcom.Teste.DAL.Interface.Entity
{
    public class Ubs
    {
        // Esta classe deve conter as seguintes propriedades:
        // vlr_latitude, vlr_longitude, nom_estab, dsc_endereco, dsc_bairro, dsc_cidade, dsc_estrut_fisic_ambiencia

        public int Id { get; set; }
        public string NomEstab { get; set; }
        public double VlrLatitude { get; set; }
        public double VlrLongitude { get; set; }
        public string DscEndereco { get; set; }
        public string DscBairro { get; set; }
        public string DscCidade { get; set; }
        public int DscEstrutFisicAmbiencia { get; set; }
        public IPoint Location { get; set; }
    }
}
