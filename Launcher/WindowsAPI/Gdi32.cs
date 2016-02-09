/* This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License along
 * with this program; if not, write to the Free Software Foundation, Inc.,
 * 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 */
using System.Runtime.InteropServices;

namespace Launcher.WindowsAPI
{
    public static class Gdi32
    {
        [StructLayout(LayoutKind.Sequential)]
        public class Rect
        {
           public int Left, Top, Right, Bottom;

           public Rect(int left, int top, int right, int bottom)
           {
             Left = left;
             Top = top;
             Right = right;
             Bottom = bottom;
           }

           public Rect(System.Drawing.Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom) { }

           public int X
           {
             get { return Left; }
             set { Right -= (Left - value); Left = value; }
           }

           public int Y
           {
             get { return Top; }
             set { Bottom -= (Top - value); Top = value; }
           }

           public int Height
           {
             get { return Bottom - Top; }
             set { Bottom = value + Top; }
           }

           public int Width
           {
             get { return Right - Left; }
             set { Right = value + Left; }
           }

           public System.Drawing.Point Location
           {
             get { return new System.Drawing.Point(Left, Top); }
             set { X = value.X; Y = value.Y; }
           }

           public System.Drawing.Size Size
           {
             get { return new System.Drawing.Size(Width, Height); }
             set { Width = value.Width; Height = value.Height; }
           }

           public static implicit operator System.Drawing.Rectangle(Rect r)
           {
             return new System.Drawing.Rectangle(r.Left, r.Top, r.Width, r.Height);
           }

           public static implicit operator Rect(System.Drawing.Rectangle r)
           {
             return new Rect(r);
           }

           public static bool operator ==(Rect r1, Rect r2)
           {
             return r1.Equals(r2);
           }

           public static bool operator !=(Rect r1, Rect r2)
           {
             return !r1.Equals(r2);
           }

           public bool Equals(Rect r)
           {
             return r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;
           }

           public override bool Equals(object obj)
           {
             if (obj is Rect)
               return Equals((Rect)obj);
             else if (obj is System.Drawing.Rectangle)
               return Equals(new Rect((System.Drawing.Rectangle)obj));
             return false;
           }

           public override int GetHashCode()
           {
             return ((System.Drawing.Rectangle)this).GetHashCode();
           }

           public override string ToString()
           {
             return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{{Left={0},Top={1},Right={2},Bottom={3}}}", Left, Top, Right, Bottom);
           }
        }

        [DllImport("user32.dll")]
        public static extern bool ClipCursor(Gdi32.Rect lpRect);
    }
}
