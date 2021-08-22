export interface AppConfig {
    env: {
        name: string;
    };
    appInsights: {
        instrumentationKey: string;
    };
    logging: {
        console: boolean;
        appInsights: boolean;
    };
    aad: {
        requireAuth: boolean;
        tenant: string;
        clientId: string;

    };
    server: {
        apiUrl: string;
        authUrl: string;
    };
    mapConfig: {
        provider: string;
        apiKey: string;
    };
}