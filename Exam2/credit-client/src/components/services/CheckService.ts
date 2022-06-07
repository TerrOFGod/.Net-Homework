import {Employment} from "../entities/Employment";
import {Pledge} from "../entities/Pledge";
import { serverAddress as server } from "../../constants";
import Result from "../entities/result";

const baseApiPath = `${server}/api/v1/subscriptions`;

export default class CheckService {

    private static readonly fetch = (info: RequestInfo, init: RequestInit | null = null): Promise<Response> => {
        init = init ?? {};
        init.mode = 'cors';
        return fetch(info, init)
    }

    static async CheckAsync(body: {
        name: string,
        surname: string,
        patronymic: string,
        issued: string,
        registration: string,
        purpose: string,
        series: number,
        number: number,
        age: number,
        credit: number,
        autoAge: number,
        date: Date,
        criminal: boolean,
        other: boolean,
        employment: Employment,
        pledge: Pledge})
    {
        let serialized = JSON.stringify(body);
        console.log(serialized)
        const response = await this.fetch(`${baseApiPath}`, {
            method: 'POST',
            body: serialized,
            headers: {
                'Content-Type': 'application/json'
            }
        });
        if (!response.ok) {
            throw new Error('Could not get result')
        }
        const result: Result = await response.json();
        return result;
    }
}