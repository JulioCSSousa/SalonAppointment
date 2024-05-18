import { Appointment } from "../Components/Appointment";



export const API_URL = 'https://localhost:7024/api'//' Substitua pela URL da sua API

export const getAppointment = async (): Promise<Appointment[]> => {
    
    
  try {
    const response = await fetch(`${API_URL}/Appointment`);
    if (!response.ok) {
        
      throw new Error('Failed to fetch agendamentos');
    }
    return await response.json();
  } catch (error) {
    console.error('Erro ao buscar agendamentos:', error);
    throw error;
    
  }
};

