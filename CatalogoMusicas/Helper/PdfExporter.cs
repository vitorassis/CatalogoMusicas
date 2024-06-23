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

        public static void ExportMusicalIndex(string filePath, Pasta pasta, List<Musica> musicas)
        {
            if (pasta == null)
            {
                throw new ArgumentException("The provided pasta collection is empty or null.");
            }

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
                            tabelasDeMusica.Add(new PdfPTable(2));
                            tabelasDeMusica[iTabela].SetWidths(new float[] { 3f, 1f });
                            PdfPCell h1 = new PdfPCell(new Phrase("Música", fonte));
                            h1.HorizontalAlignment = 1;
                            PdfPCell h2 = new PdfPCell(new Phrase("Índice", fonte));
                            h2.HorizontalAlignment = 1;
                            tabelasDeMusica[iTabela].AddCell(h1);
                            tabelasDeMusica[iTabela].AddCell(h2);
                        }

                        tabelasDeMusica[iTabela].AddCell(new Phrase(musicas[i].Nome, fonte));
                        tabelasDeMusica[iTabela].AddCell(new Phrase(musicas[i].Indice.ToString(), fonte));
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
