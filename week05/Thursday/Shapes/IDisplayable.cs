namespace Shapes
{
	public interface IDisplayable
	{
		System.Drawing.Color Color { get; set; }

		void Draw(System.Drawing.Graphics g);
	}
}
