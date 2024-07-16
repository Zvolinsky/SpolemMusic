import { Card } from "react-bootstrap";
import { Link } from "react-router-dom";
import AudioPlayer from "../ProductCard/AudioPlayer";
import Rating from "../ProductScreen/Rating";
import "../../styles/index.css";

interface ProductCardProps {
  product: ProductType;
}
const ProductCard: React.FC<ProductCardProps> = ({
  product,
}: ProductCardProps) => {
  return (
    <Card className="my-3 p-3 rounded">
      <div>
        <AudioPlayer image={product.coverImage} music={product.previewMusic} />
      </div>
      <Card.Body>
        <Link
          className="textAnchor"
          to={`/product/${product._id}`}
          style={{
            textDecoration: "none",
          }}
        >
          <Card.Title
            className="textAnchor"
            as="div"
            style={{
              overflow: "hidden",
              textOverflow: "ellipsis",
              whiteSpace: "nowrap",
            }}
          >
            <strong
              className="textAnchor"
              style={{
                color: "#000",
                fontSize: 19,
              }}
            >
              {product.title}
            </strong>
          </Card.Title>
        </Link>
        <Link to={`/product/${product._id}`} style={{ textDecoration: "none" }}>
          <Card.Title
            as="div"
            style={{
              overflow: "hidden",
              textOverflow: "ellipsis",
              whiteSpace: "nowrap",
            }}
          >
            {product?.artist.map((artist: string, index: number) => (
              <h6
                className="textAnchor"
                style={{ display: "inline", color: "#000" }}
              >
                {(index ? " / " : "") + artist}
              </h6>
            ))}
          </Card.Title>
        </Link>
        <Card.Text as="div">
          <Rating value={product.productRating} />
        </Card.Text>
        <Card.Text as="h5">{product.price}zł</Card.Text>
      </Card.Body>
    </Card>
  );
};

export default ProductCard;
