using AMcom.Teste.DAL.Interface.Entity;
using AMcom.Teste.Service.Interface.DTO;
using AMcom.Teste.Service.Interface.Enum;
using GeoAPI.Geometries;
using NetTopologySuite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AMcom.Teste.Service.Interface.Extension
{
    public static class BasicExtension
    {
        public static DbGeography ToPoint(Double latitude, Double longitude)
        {
            
            String lon = NormalizeLongitude(longitude).ToString(CultureInfo.InvariantCulture);
            String lat = NormalizeLatitude(latitude).ToString(CultureInfo.InvariantCulture);
            return DbGeography.PointFromText(string.Format("POINT({0} {1})", lon, lat), DbGeography.DefaultCoordinateSystemId);
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
        public static string GetDescriptionEnum(this System.Enum value)
        {
            var enumMember = value.GetType().GetMember(value.ToString()).FirstOrDefault();
            var descriptionAttribute =
                enumMember == null
                    ? default(DescriptionAttribute)
                    : enumMember.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return
                descriptionAttribute == null
                    ? value.ToString()
                    : descriptionAttribute.Description;
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
        public static double NormalizeLatitude(double latitude)
        {
            return Math.Min(Math.Max(latitude, -90d), 90d);
        }
        public static double NormalizeLongitude(double longitude)
        {
            if (longitude < -180d)
            {
                longitude = ((longitude + 180d) % 360d) + 180d;
            }
            else if (longitude > 180d)
            {
                longitude = ((longitude - 180d) % 360d) - 180d;
            }

            return longitude;
        }
    }
}
