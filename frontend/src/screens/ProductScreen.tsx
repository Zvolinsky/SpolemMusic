import { useState, useEffect } from "react";
import { useParams, Link } from "react-router-dom";
import { Row, Col, Image, ListGroup, Card, Button } from "react-bootstrap";
import axios from "axios";
import Rating from "../components/ProductScreen/Rating";
import formatTime from "../utils/formatTime";
import SkeletonRating from "../components/ProductScreen/SkeletonRating";

const ProductScreen: React.FC = () => {
  const [product, setProduct] = useState<ProductType | null>(null);
  const [ready, setReady] = useState<boolean>(false);
  const { id: productId } = useParams();
  useEffect(() => {
    const fetchProducts = async () => {
      const { data } = await axios.get(`/api/products/${productId}`);
      setProduct(data);
      setReady(true);
    };
    fetchProducts();
  });

  return (
    <>
      <Link className="btn btn-light my-3" to="/">
        Go Back
      </Link>
      <Row>
        <Col md="5">
          {ready ? (
            <Image src={product?.coverImage} alt={product?.title} fluid />
          ) : (
            <div
              className="skeleton"
              style={{ width: "100%", height: "33em", borderRadius: 20 }}
            ></div>
          )}
        </Col>
        <Col md="4">
          {ready ? (
            <ListGroup variant="flush">
              <ListGroup.Item>
                <h3>{product?.title}</h3>
                <h4>
                  {product?.artist.map((artist: string, index: number) => (
                    <h4 className="textAnchor" style={{ display: "inline" }}>
                      {(index ? " / " : "") + artist}
                    </h4>
                  ))}
                </h4>
              </ListGroup.Item>
              <ListGroup.Item>
                <Rating value={product?.productRating} />
              </ListGroup.Item>

              <ListGroup.Item>
                <Row>
                  <Col>Format:</Col>
                  <Col>{product?.format}</Col>
                </Row>
              </ListGroup.Item>
              <ListGroup.Item>
                <Row>
                  <Col>Rok:</Col>
                  <Col>{product?.year}</Col>
                </Row>
              </ListGroup.Item>
              <ListGroup.Item>
                <Row>
                  <Col>Kraj:</Col>
                  <Col>{product?.country}</Col>
                </Row>
              </ListGroup.Item>
              <ListGroup.Item>
                <Row>
                  <Col>Rodzaj:</Col>
                  <Col>
                    {product?.genre.map((genre: string, index: number) => (
                      <p style={{ display: "inline" }}>
                        {(index ? ", " : "") + genre}
                      </p>
                    ))}
                  </Col>
                </Row>
              </ListGroup.Item>
              <ListGroup.Item>
                <Row>
                  <Col>Wytwórnia:</Col>
                  <Col>
                    {product?.label} – {product?.catalogueNum}
                  </Col>
                </Row>
              </ListGroup.Item>

              <ListGroup.Item>
                <Row>
                  <Col>Cena:</Col>
                  <Col>{product?.price}zł</Col>
                </Row>
              </ListGroup.Item>
            </ListGroup>
          ) : (
            <ListGroup variant="flush">
              <ListGroup.Item>
                <div className="skeleton" style={{ borderRadius: 10 }}>
                  <h3 style={{ opacity: 0, userSelect: "none" }}>TITLE</h3>
                </div>
                <div className="skeleton" style={{ borderRadius: 10 }}>
                  <h4 style={{ opacity: 0, userSelect: "none" }}>ARTIST</h4>
                </div>
              </ListGroup.Item>
              <ListGroup.Item>
                <SkeletonRating />
              </ListGroup.Item>
              {Array(6)
                .fill(0)
                .map(() => (
                  <ListGroup.Item>
                    <Row>
                      <Col className="skeleton" style={{ borderRadius: 10 }}>
                        <span style={{ opacity: 0, userSelect: "none" }}>
                          NONE
                        </span>
                      </Col>
                    </Row>
                  </ListGroup.Item>
                ))}
            </ListGroup>
          )}
        </Col>
        <Col md="3">
          {ready ? (
            <Card>
              <ListGroup variant="flush">
                <ListGroup.Item>
                  <Row>
                    <Col>Cena:</Col>
                    <Col>
                      <strong>{product?.price}zł</strong>
                    </Col>
                  </Row>
                </ListGroup.Item>
                <ListGroup.Item>
                  {product?.countInStock !== undefined &&
                  product.countInStock > 0 ? (
                    <strong style={{ color: "#47ba0d" }}>W Magazynie</strong>
                  ) : (
                    <strong style={{ color: "#ba270d" }}>
                      Brak w magazynie
                    </strong>
                  )}
                </ListGroup.Item>
                <ListGroup.Item>
                  <Button
                    className="btn-block"
                    type="button"
                    disabled={product?.countInStock === 0}
                  >
                    Dodaj do koszyka
                  </Button>
                </ListGroup.Item>
              </ListGroup>
            </Card>
          ) : (
            <Card>
              <ListGroup variant="flush">
                <ListGroup.Item>
                  <Row>
                    <Col className="skeleton" style={{ borderRadius: 10 }}>
                      <span style={{ opacity: 0, userSelect: "none" }}>
                        NONE
                      </span>
                    </Col>
                  </Row>
                </ListGroup.Item>
                <ListGroup.Item>
                  <Row>
                    <Col className="skeleton" style={{ borderRadius: 10 }}>
                      <span style={{ opacity: 0, userSelect: "none" }}>
                        NONE
                      </span>
                    </Col>
                  </Row>
                </ListGroup.Item>
              </ListGroup>
            </Card>
          )}
        </Col>
      </Row>
      <Row className="my-5 w-50">
        {ready && <audio controls src={product?.previewMusic} />}
      </Row>
      <Row>
        {ready && (
          <>
            <h4>Lista utworów:</h4>
            <ListGroup className="my-5 w-50 " as="ol">
              {product?.tracklist.map((item, index: number) => (
                <ListGroup.Item as="li">
                  <div className="d-flex justify-content-between align-items-start">
                    <div>
                      <p style={{ fontSize: 19, fontWeight: 500 }}>
                        {index + 1}. {item.trackName}
                      </p>
                    </div>
                    <div>{formatTime(item.trackLength)}</div>
                  </div>
                  <div>
                    <p
                      className="textAnchor"
                      style={{ fontSize: 15, fontWeight: 400 }}
                    >
                      {item.trackArtist}
                    </p>
                  </div>
                </ListGroup.Item>
              ))}
            </ListGroup>
          </>
        )}
      </Row>
    </>
  );
};

export default ProductScreen;
