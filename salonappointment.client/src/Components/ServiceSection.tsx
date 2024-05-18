import React from 'react';
import { Container, Typography, Grid, Card, CardContent, CardMedia } from '@mui/material';

const services = [
    {
        title: 'Corte de Cabelo',
        description: 'Cortes modernos e clássicos para todos os gostos.',
        image: '/path/to/image1.jpg',
    },
    {
        title: 'Barba',
        description: 'Aparos e modelagem de barba.',
        image: '/path/to/image2.jpg',
    },
    {
        title: 'Tratamentos Capilares',
        description: 'Cuidado especial para o seu cabelo.',
        image: '/path/to/image3.jpg',
    },
];

const ServicesSection: React.FC = () => {
    return (
        <Container sx={{ py: 8 }}>
            <Typography variant="h4" component="h2" gutterBottom>
                Nossos Serviços
            </Typography>
            <Grid container spacing={4}>
                {services.map((service, index) => (
                    <Grid item key={index} xs={12} sm={6} md={4}>
                        <Card>
                            <CardMedia
                                component="img"
                                height="140"
                                image={service.image}
                                alt={service.title}
                            />
                            <CardContent>
                                <Typography variant="h5" component="h3">
                                    {service.title}
                                </Typography>
                                <Typography variant="body2" color="textSecondary">
                                    {service.description}
                                </Typography>
                            </CardContent>
                        </Card>
                    </Grid>
                ))}
            </Grid>
        </Container>
    );
};

export default ServicesSection;
