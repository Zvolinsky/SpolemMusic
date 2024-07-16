import { FaStar } from "react-icons/fa";

const SkeletonRating: React.FC = () => {
  return Array(5)
    .fill(0)
    .map(() => (
      <span>
        <FaStar color="gray" />
      </span>
    ));
};

export default SkeletonRating;
