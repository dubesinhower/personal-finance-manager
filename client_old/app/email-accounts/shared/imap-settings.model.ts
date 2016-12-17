import { Socket } from '../shared';
import { Login } from '../../shared';

export class ImapSettings {
    constructor(
        public emailAccountId: number,
        public connection: Socket,
        public login: Login
    ) { }
}
