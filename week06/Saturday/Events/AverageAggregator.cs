using System;
using System.Xml.Schema;

namespace Events
{
    public class AverageAggregator
    {
	    public event EventHandler AverageChanged;

	    private decimal _average;
	    private int _numberCount;

	    public AverageAggregator()
	    {
		    _average = 0;
		    _numberCount = 0;
	    }

	    public decimal Average
	    {
		    get { return _average; }
		    set
		    {
			    if (value != _average)
			    {
				    OnAverageChanged();
			    }

			    _average = value;
		    }
	    }

	    public void AddNumber(int number)
	    {
		    _numberCount++;
		    Average = (Average*(_numberCount - 1) + number)/_numberCount;
	    }

	    protected virtual void OnAverageChanged()
	    {
		    AverageChanged?.Invoke(this, EventArgs.Empty);
	    }
    }
}
