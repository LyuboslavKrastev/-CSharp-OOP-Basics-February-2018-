using System;
using System.Text;

class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }
    private double Length
    {
        get
        {
            return this.length;
        }
        set
        {
            this.length = value;
        }
    }
    private double Width
    {
        get
        {
            return this.width;
        }
        set
        {
            this.width = value;
        }
    }
    private double Height
    {
        get
        {
            return this.height;
        }
        set
        {
            this.height = value;
        }
    }


    public double Volume()
    {
        double Volume = this.Length * this.Width * this.Height;
        return Volume;
    }
    public double LateralSurfaceArea()
    {

        double LateralSurfaceArea = 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        return LateralSurfaceArea;
    }
    public double SurfaceArea()
    {
        double SurfaceArea = 2 * (this.Length * this.Width) + 2 * (this.Length * this.Height) + 2 * (this.Width * this.Height);
        return SurfaceArea;
    }

    public override string ToString()
    {
        var surfaceAr = this.SurfaceArea();
        var lat = this.LateralSurfaceArea();
        var vol = this.Volume();
        var result = new StringBuilder();
        result.AppendLine($"Surface Area - {surfaceAr:f2}");
        result.AppendLine($"Lateral Surface Area - {lat:f2}");
        result.AppendLine($"Volume - {vol:f2}");
        return result.ToString().Trim();
    }
}
