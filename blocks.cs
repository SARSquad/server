using System;


public class blocks
{
    private double Latitude;
    private double Longitude;
    private int Row;
    private int Column; // should one of these be a char?
    private string Searcher_ID;
    private bool IsSearched;

    // default constructor for blocks class 
	public blocks()
	{
        Latitude = 0;
        Logitude = 0;
        Row = 0;
        Column = 0;
        Searcher_ID = 0000000;
        IsSearched = false;
	}

    public blocks(double longitude, double latitude, int row, int column, string searcher_id, bool issearched)
    {
        //using lowercase letters for the input parameters
        Latitude = longitude;
        Logitude = latitude;
        Row = row;
        Column = column;
        Searcher_ID = searcher_id;
        IsSearched = issearched;
    }

    //Getter for all elements in object

    public double getLatitude()
    {
        return Latitude;
    }

    public void setLatitude(double latitude)
    {
        latitude = Latitude;
    }


    public double getLongitude()
    {
        return Longitude;
    }

    public void setLongitude(double longitude)
    {
        Longitude = longitude;
    }

    public int getRow()
    {
        return Row;
    }

    public void setRow(int row)
    {
        Row = row;
    }
    

    public int getColumn()
    {
        return Column;
    }

    public void setColumn(int column)
    {
        Column = column;
    }

    public string getSearcher_ID()
    {
        return Searcher_ID;
    }

    public void setSearcher_ID(string searcher_id)
    {
        Searcher_ID = searcher_id;
    }

    public bool getIsSearched()
    {
        return IsSearched;
    }

    public void setIsSearched(bool issearched)
    {
        IsSearched = issearched;
    }

}

