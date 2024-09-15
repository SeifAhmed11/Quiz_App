import { AppBar, Button, Container, Toolbar, Typography } from '@mui/material'
import React from 'react'
import { Outlet, useNavigate } from 'react-router'
import useStateContext from '../hooks/useStateContext'

export default function Layout() {
    const { resetContext } = useStateContext()
    const navigate = useNavigate()

    const logout = () => {
        resetContext()
        navigate("/")
    }

    return (
        <>
            <AppBar position="sticky">
                <Toolbar sx={{ width: 640, m: 'auto' }}>
                    <Typography
                        variant="h4"
                        align="center"
                        sx={{ flexGrow: 1 }}>
                        Quiz App
                    </Typography>
                    <Button sx={{ color: 'white',fontWeight:'900',backgroundColor: '#800f00',fontSize:'18px','&:hover': {
                                    backgroundColor: '#520000', // Change to the desired hover color
                                    color: 'white' // Optional: change text color on hover if needed
                                  }}}
                            onClick={logout}>Logout</Button>
                </Toolbar>
            </AppBar>
            <Container>
                <Outlet />
            </Container>
        </>
    )
}