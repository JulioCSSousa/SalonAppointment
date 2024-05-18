import React, { useState } from 'react';
import { Container, Typography, TextField, Button, List, ListItem, ListItemText } from '@mui/material';
import { getAppointment } from '../services/api';


export interface Client {
    clientId: string;  // Ou outro tipo adequado se o ID não for um string
    name: string;
    phone: string

}

export interface Appointment {
    appointmentCode: string; // Guid
    client: Client;
    dataHora: string; // DateTime
    observation: string;
    serviceId : number
}

const Appointments: React.FC = () => {
    const [appointments, setAppointments] = useState<Appointment[]>([]);
    const [loading, setLoading] = useState<boolean>(false);
    const [error, setError] = useState<string | null>(null);

    const handleGetAppointments = async () => {
        setLoading(true);
        setError(null);
        try {
            const data = await getAppointment();
            console.log('Appointments received:', data);
            setAppointments(data);
        } catch (err) {
            console.error('Error fetching appointments:', err);
            setError('Failed to fetch appointments');
        } finally {
            setLoading(false);
        }
    };

    return (
        <Container sx={{ py: 8 }}>
            <Typography variant="h4" component="h2" gutterBottom>
                Fetch Appointments
            </Typography>
            <TextField
                label="Search"
                variant="outlined"
                fullWidth
                margin="normal"
            />
            <Button
                variant="contained"
                color="primary"
                onClick={handleGetAppointments}
                disabled={loading}
            >

            {loading ? 'Loading...' : 'Fetch Appointments'}
            
            </Button>
            {error && <Typography color="error">{error}</Typography>}
            <List>
                {appointments.map((appointment) => (
                    <ListItem key={appointment.appointmentCode}>
                        <ListItemText
                            primary={`Id ${appointment.appointmentCode} - Data ${appointment.dataHora} - ClientId ${appointment.client.clientId} - Name ${appointment.client.name} - Phone ${appointment.client.phone}`}
                            secondary={`Observation: ${appointment.observation}, Service ID: ${appointment.serviceId}`}
                        />
                    </ListItem>
                ))}
            </List>
        </Container>
    );
};

export default Appointments;
