import { ENV } from "./env";

export function api(...params) {
	return `${ENV.API_URL}${params.join("")}`;
}
