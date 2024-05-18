import React from 'react';
import { Container, Typography, Button, Box } from '@mui/material';

const HeroSection: React.FC = () => {
  return (
    <Box
    >
      <Container>
        <Typography variant="h2" component="h1" gutterBottom>
          Bem-vindo à Barbearia
        </Typography>
        <Typography variant="h5" component="p" gutterBottom>
          Os melhores cortes e atendimento
        </Typography>
        <Button variant="contained" color="primary" size="large">
          Agende seu horário
        </Button>
      </Container>
    </Box>
  );
};

export default HeroSection;