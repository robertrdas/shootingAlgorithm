		/*
		It receives a list with the vertices of the polygon, the x coordinate of the point and the y coordinate of the point. 
		Originally it was implemented to verify if a point was contained within the polygon of a city. 
		Coordinates given in latitude and longitude
		*/
		private bool shootingAlgorithm( List<object[]> polygon , double xPoint , double yPoint ) {
			int count = 0;
			double x0, x1, y0, y1;
			for( int i = 0; i<polygon.Count()-1; i++ ) {

				double xVertice = double.Parse(polygon[i][0].ToString());
				double yVertice = double.Parse(polygon[i][1].ToString());
				if( yVertice<double.Parse(polygon[i+1][1].ToString()) ) {
					x0=xVertice;
					x1=double.Parse(polygon[i+1][0].ToString());
					y0=yVertice;
					y1=double.Parse(polygon[i+1][1].ToString());
				} else {
					x0=double.Parse(polygon[i+1][0].ToString());
					x1=xVertice;
					y0=double.Parse(polygon[i+1][1].ToString());
					y1=yVertice;
				}

				if( yPoint>y0&&yPoint<y1&&( xPoint>x0||xPoint>x1 ) ) {
					if( ( xPoint<x0&&xPoint<x1 ) ) {
						count++;
					} else {
						double dx = x0-x1;
						double xc = x0;
						if( dx!=0 ) {
							xc+=( yPoint-y0 )*dx/( y0-y1 );
						}
						if( xPoint>xc ) {
							count++;
						}
					}
				}
			}
			if( double.Parse(polygon[polygon.Count()-1][1].ToString())<double.Parse(polygon[0][1].ToString()) ) {
				x0=double.Parse(polygon[polygon.Count()-1][0].ToString());
				x1=double.Parse(polygon[0][0].ToString());
				y0=double.Parse(polygon[polygon.Count()-1][1].ToString());
				y1=double.Parse(polygon[0][1].ToString());
			} else {
				x1=double.Parse(polygon[polygon.Count()-1][0].ToString());
				x0=double.Parse(polygon[0][0].ToString());
				y1=double.Parse(polygon[polygon.Count()-1][1].ToString());
				y0=double.Parse(polygon[0][1].ToString());
			}

			if( yPoint>y0&&yPoint<y1&&( xPoint>x0||xPoint>x1 ) ) {
				if( ( xPoint<x0&&xPoint<x1 ) ) {
					count++;
				} else {
					double dx = x0-x1;
					double xc = x0;
					if( dx!=0 ) {
						xc+=( yPoint-y0 )*dx/( y0-y1 );
					}
					if( xPoint>xc ) {
						count++;
					}
				}
			}

			if( count%2==1 ) {
				return true;
			} else {
				return false;
			}
			
		}