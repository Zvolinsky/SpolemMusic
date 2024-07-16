import { Button } from "react-bootstrap";
import { Card } from "react-bootstrap";
import { useRef, useState } from "react";
import { FaPlay, FaPause } from "react-icons/fa";

interface AudioPlayerProps {
  image: string;
  music: string;
}

const AudioPlayer: React.FC<AudioPlayerProps> = ({
  image,
  music,
}: AudioPlayerProps) => {
  const [active, setActive] = useState<boolean>(false);
  const [play, setPlay] = useState<boolean>(false);
  const playerRef = useRef<HTMLAudioElement>(null);

  function toggleAudio(): void {
    if (!play) {
      playerRef.current?.play();
      setPlay(true);
    } else {
      playerRef.current?.pause();
      setPlay(false);
    }
  }

  return (
    <div
      style={{
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
      }}
      onMouseEnter={(): void => setActive(true)}
      onMouseLeave={(): void => setActive(false)}
    >
      <Card.Img
        src={image}
        variant="top"
        style={{
          filter: active ? "brightness(50%)" : "brightness(100%)",
          transition: "0.3s",
        }}
      />
      <Button
        size="lg"
        style={{
          width: "50%",
          height: "50%",
          position: "absolute",
          opacity: active ? 100 : 0,
          transition: "0.3s",
          backgroundColor: "transparent",
          border: "none",
        }}
        onClick={toggleAudio}
      >
        {play ? <FaPause size={50} /> : <FaPlay size={50} />}
      </Button>
      <audio ref={playerRef} src={music} />
    </div>
  );
};

export default AudioPlayer;
