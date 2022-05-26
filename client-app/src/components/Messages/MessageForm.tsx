import React from 'react'
import { Button, Input, Segment } from 'semantic-ui-react'

export const MessageForm = () => {
    return (
        <Segment>
            <Input
                fluid
                name="message"
                style={{marginBotton: '0.7em'}}
                label={<Button icon={'add'}></Button>}
                labelPosition="left"
                placeholder="Write your message"
                >
            </Input>
            <Button.Group icon widths="2">
                <Button color="orange"
                        content="Add Replay"
                        labelPosition="left"
                        icon="edit"/>
                        <Button color="teal"
                        content="Upload Media"
                        labelPosition="right"
                        icon="cloud upload"/>
            </Button.Group>
        </Segment>
    )
}
export default MessageForm