﻿using AMcom.Teste.DAL.Interface.Entity;
using AMcom.Teste.Service.Interface.DTO;
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

        public static List<UbsDTO> ImportCsvToUbs(string path)
        {
            List<UbsDTO> listData = new List<UbsDTO>();
            UbsDTO importingData;
            string line;
            string[] row = new string[7];
            bool titulo = true;

            using (FileStream fileStream = new FileStream(
                    path,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.ReadWrite))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (!titulo)
                        {
                            importingData = new UbsDTO();
                            row = line.Split(',');

                            importingData = new UbsDTO()
                            {
                                VlrLatitude = Double.Parse(row[0]),
                                VlrLongitude = Double.Parse(row[1]),
                                Nome = row[2],
                                DscEndereco = row[3],
                                DscBairro = row[4],
                                DscCidade = row[5],
                                Avaliacao = ConverterAvaliacao(row[6])
                            };
                            listData.Add(importingData);
                        }
                        titulo = false;

                    }
                    return listData;
                }
            }
        }
    }
}
