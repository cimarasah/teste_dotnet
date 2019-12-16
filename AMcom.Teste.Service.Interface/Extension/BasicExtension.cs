using AMcom.Teste.DAL.Interface.Entity;
using AMcom.Teste.Service.Interface.Enum;
using GeoAPI.Geometries;
using NetTopologySuite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AMcom.Teste.Service.Interface.Extension
{
    public static class BasicExtension
    {
        public static IPoint ToPoint(Double latitude, Double longitude)
        {
            // SRID = 4326 -> Spatial reference system used by Google maps(WGS84)
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            return geometryFactory.CreatePoint(new Coordinate(latitude, longitude));
        }
        public static AvaliacaoEnum ConverterAvaliacao(string DscEstrutFisicAmbiencia)
        {
            switch (DscEstrutFisicAmbiencia)
            {
                case "Desempenho muito acima da média":
                    return AvaliacaoEnum.MuitoAcimaMedia;
                case "Desempenho acima da média":
                    return AvaliacaoEnum.AcimaDaMedia;
                case "Desempenho mediano ou  um pouco abaixo da média":
                    return AvaliacaoEnum.MedianoOuPoucoAbaixoMedia;
                default:
                    return AvaliacaoEnum.MedianoOuPoucoAbaixoMedia;
            }
        }

        public static List<Ubs> ImportCsvToUbs(string path)
        {
            StreamReader sr = new StreamReader(path);
            List<Ubs> listData = new List<Ubs>();
            Ubs importingData;
            string line;
            string[] row = new string[7];
            while ((line = sr.ReadLine()) != null)
            {
                importingData = new Ubs();
                row = line.Split(',');

                importingData = new Ubs()
                {
                    VlrLatitude = Double.Parse(row[0]),
                    VlrLongitude = Double.Parse(row[1]),
                    NomEstab = row[2],
                    DscEndereco = row[3],
                    DscBairro = row[4],
                    DscCidade = row[5],
                    DscEstrutFisicAmbiencia = (int)BasicExtension.ConverterAvaliacao(row[6])
                };
                listData.Add(importingData);
            }
            return listData;
        }
    }
}
