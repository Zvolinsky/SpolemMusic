import { useEffect, useState } from "react";
import axios from "axios";
import { Row, Col } from "react-bootstrap";
import ProductCard from "../components/Home/ProductCard";
import SkeletonProductCard from "../components/Home/SkeletonProductCard";

const HomeScreen: React.FC = () => {
  const [products, setProducts] = useState<ProductType[]>([]);
  const [ready, setReady] = useState<boolean>(false);

  useEffect(() => {
    const fetchProducts: () => Promise<void> = async () => {
      const { data } = await axios.get("/api/products");
      setProducts(data);
      setReady(true);
    };
    fetchProducts();
  }, []);

  return (
    <>
      {ready ? (
        <Row>
          {products.map((item: ProductType, index: number) => (
            <Col sm={12} md={6} lg={4} xl={3}>
              <ProductCard key={index} product={item} />
            </Col>
          ))}
        </Row>
      ) : (
        <Row>
          {Array(8)
            .fill(0)
            .map(() => (
              <Col sm={12} md={6} lg={4} xl={3}>
                <SkeletonProductCard />
              </Col>
            ))}
        </Row>
      )}
    </>
  );
};

export default HomeScreen;
