import { Card } from "react-bootstrap";
import SkeletonRating from "../ProductScreen/SkeletonRating";
import "../../styles/index.css";

const SkeletonProductCard = () => {
  return (
    <Card className="my-3 p-3 rounded">
      <div>
        <div
          className="skeleton"
          style={{
            height: 270,
            borderRadius: 10,
            userSelect: "none",
          }}
        ></div>
      </div>
      <Card.Body>
        <Card.Title
          className="skeleton"
          style={{
            borderRadius: 10,
          }}
        >
          <strong
            style={{
              fontSize: 19,
              opacity: 0,
              userSelect: "none",
            }}
          >
            TITLE
          </strong>
        </Card.Title>
        <Card.Title
          className="skeleton"
          style={{
            borderRadius: 10,
            width: "75%",
          }}
        >
          <h6
            style={{
              opacity: 0,
              userSelect: "none",
            }}
          >
            ARTIST
          </h6>
        </Card.Title>
        <Card.Text as="div">
          <SkeletonRating />
        </Card.Text>
        <div
          className="skeleton"
          style={{
            borderRadius: 10,
            width: "30%",
          }}
        >
          <Card.Text
            as="h5"
            style={{
              userSelect: "none",
              opacity: 0,
            }}
          >
            PRICE
          </Card.Text>
        </div>
      </Card.Body>
    </Card>
  );
};

export default SkeletonProductCard;
