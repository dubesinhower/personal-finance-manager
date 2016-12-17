import { Token } from '../../user-account';
import { EmailAccount } from '../../email-accounts';

export interface AppStore {
    userToken: Token;
    emailAccounts: EmailAccount[];
    selectedEmailAccount: number;
    googleOAuthSecurityToken: string;
}
