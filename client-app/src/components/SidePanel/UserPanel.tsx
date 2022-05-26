import React from 'react'
import { Dropdown, Grid, Header, Icon } from 'semantic-ui-react'

export const UserPanel = () => {
    const dropDownOptions =()=>[{
        key: 'user',
        text: (
            <span> Logged as <strong>User</strong></span>
        ),
        disabled: true
    },
    {
        key: 'avatar',
        text: (
            <span> Change Avatar </span>
        ),
        disabled: true
    }]
    return (
        <Grid style={{ background: '4c3c4c', margin: 0}}>
            <Grid.Column style={{padding: '1.2em', margin: 0}}>
                <Grid.Row style={{ padding: '1.2em', margin: 0}}>
                    <Header inverted floated="left" as="h2">
                        <Icon name="code"/>
                        <Header.Content >NetChat</Header.Content>
                    </Header>
                </Grid.Row>
                <Header style={{ padding: '0.25em'}} as="h4" inverted>
                    <Dropdown trigger={<span>User</span>}
                    options={dropDownOptions()}>

                    </Dropdown>
                </Header>
            </Grid.Column>
        </Grid>
    )
}
