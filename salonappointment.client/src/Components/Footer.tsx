import React from 'react';
import { Box, Container, Typography, Link } from '@mui/material';

const Footer: React.FC = () => {
    return (
        <Box sx={{ bgcolor: 'primary.main', color: '#fff', py: 3 }}>
            <Container>
                <Typography variant="body1">© 2024 Barbearia. Todos os direitos reservados.</Typography>
                <Link href="#" color="inherit" underline="hover">
                    Termos de Uso
                </Link>
                {' | '}
                <Link href="#" color="inherit" underline="hover">
                    Política de Privacidade
                </Link>
            </Container>
        </Box>
    );
};

export default Footer;
