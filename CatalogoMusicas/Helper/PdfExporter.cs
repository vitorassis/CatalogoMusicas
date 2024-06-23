using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CatalogoMusicas.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace CatalogoMusicas.Helper
{
    public static class PdfExporter
    {
        static int POR_TABELA = 80;

        public static int Comparar(Musica m1, Musica m2)
        {
            return m1.Nome.CompareTo(m2.Nome);
        }

        public static void ExportMusicalIndex(string filePath, Pasta pasta)
        {
            if (pasta == null)
            {
                throw new ArgumentException("The provided pasta collection is empty or null.");
            }

            List<Musica> musicas = pasta.Musicas;
            musicas.Sort(Comparar);

            using (var document = new Document(PageSize.A4, 0, 0, 0, 0))
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    PdfWriter.GetInstance(document, fileStream);
                    document.Open();

                    List<PdfPTable> tabelasDeMusica = new List<PdfPTable>(musicas.Count/POR_TABELA + 1);
                    int iTabela = -1;

                    iTextSharp.text.Font fonte = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 6);

                   for (int i = 0; i < musicas.Count; i++)
                    {
                        if(i == 0 || i % POR_TABELA == 0)
                        {
                            iTabela++;
                            tabelasDeMusica.Add(new PdfPTable(3));
                            tabelasDeMusica[iTabela].SetWidths(new float[] { 2f, 1f, .5f });
                            PdfPCell h1 = new PdfPCell(new Phrase("Música", fonte));
                            h1.Colspan = 2;
                            h1.HorizontalAlignment = 1;
                            PdfPCell h2 = new PdfPCell(new Phrase("Índice", fonte));
                            h2.HorizontalAlignment = 1;
                            tabelasDeMusica[iTabela].AddCell(h1);
                            tabelasDeMusica[iTabela].AddCell(h2);
                        }
                        BaseColor cor = i % 2 == 0 ? BaseColor.GRAY : BaseColor.WHITE;

                        PdfPCell nome = new PdfPCell(new Phrase(musicas[i].Nome, fonte));
                        nome.BackgroundColor = cor;

                        string tons = "";
                        foreach (Tom t in musicas[i].Tons)
                        {
                            tons += t.Tonalidade + ", ";
                        }
                        tons = tons.Substring(0, tons.Length - 2);
                        PdfPCell tom = new PdfPCell(new Phrase(tons, fonte));
                        tom.BackgroundColor = cor;
                        
                        PdfPCell indice = new PdfPCell(new Phrase(musicas[i].Indice.ToString(), fonte));
                        indice.HorizontalAlignment = 2;
                        indice.BackgroundColor = cor;


                        tabelasDeMusica[iTabela].AddCell(nome);
                        tabelasDeMusica[iTabela].AddCell(tom);
                        tabelasDeMusica[iTabela].AddCell(indice);
                    }

                    PdfPTable tabelaGeral = new PdfPTable(tabelasDeMusica.Count);

                   foreach(PdfPTable tabela in tabelasDeMusica)
                    {
                        tabelaGeral.AddCell(tabela);
                    }

                   document.Add(tabelaGeral);

                    document.Close();
                }
            }
        }
    }
}
