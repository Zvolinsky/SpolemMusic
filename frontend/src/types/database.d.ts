interface ProductType {
  _id: string;
  title: string;
  artist: string[];
  format: string;
  genre: string[];
  year: number;
  country: string;
  description: string;
  tracklist: {
    trackName: string;
    trackLength: number;
    trackArtist?: string;
  }[];
  label: string;
  catalogueNum: string;
  coverImage: string;
  previewMusic: string;
  productRating: number;
  countInStock: number;
  price: number;
  productReviews?: {
    user: string;
    reviewRating: number;
    reviewComment: string;
  }[];
}
