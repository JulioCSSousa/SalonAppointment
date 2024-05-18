import React from 'react';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';

const Navbar: React.FC = () => {
    return (
        <AppBar position="static">
            <Toolbar>
                <Typography variant="h6" style={{ flexGrow: 1 }}>
                    Barbearia
                </Typography>
                <Button color="inherit">Início</Button>
                <Button color="inherit">Serviços</Button>
                <Button color="inherit">Contato</Button>
            </Toolbar>
        </AppBar>
    );
};

export default Navbar;
