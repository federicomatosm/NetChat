import { action, makeObservable, observable, configure, runInAction } from 'mobx';
import { createContext } from 'react';
import agent from '../api/agent';
import { IChannel } from '../models/channels';

configure({enforceActions: 'always'})
class ChannelStore {
    @observable channels: IChannel[] = []
    @observable isModalVisible: boolean = false

    constructor() {
        makeObservable(this)
    }

    @action loadChannels = async () => {
        try {
            var response = await agent.Channels.list()
            runInAction(()=>  response.forEach( (channel) => this.channels.push(channel)))
           
        } catch (err) {
            console.log(err)
        }

    }

    @action showModal = (show: boolean) => {
        this.isModalVisible = show
    }

    @action createChannel = async (channel: IChannel) => {
        try {
            await agent.Channels.create(channel)
            runInAction(()=> this.channels.push(channel))
            
        } catch (err) {
            console.log("ocurio un error creando el channel "+err)
        }
    }
}

export default createContext(new ChannelStore())