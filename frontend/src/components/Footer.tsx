import { Container, Row, Col } from "react-bootstrap";

const Footer: React.FC = () => {
  const currentYear: number = new Date().getFullYear();

  return (
    <footer>
      <Container>
        <Row>
          <Col className="text-center py-3">
            <p>SpołemMusic &copy; {currentYear}</p>
          </Col>
        </Row>
      </Container>
    </footer>
  );
};

export default Footer;
