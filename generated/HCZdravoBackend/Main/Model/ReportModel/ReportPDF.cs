// File:    ReportPDF.cs
// Created: Monday, June 01, 2020 5:02:56 PM
// Purpose: Definition of Class ReportPDF



using PdfSharp.Pdf;

public class ReportPDF
{
    public string Id { get; set; }
    public PdfDocument Document { get; set; }

    public ReportPDF(PdfDocument pdf, string id)
    {
        this.Document = pdf;
        this.Id = id;
    }
}
