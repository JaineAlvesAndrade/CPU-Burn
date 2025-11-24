**CPU e GPU Burn**

Aplicação que realiza teste de estresse na CPU e na GPU do seu computador.

Para rodar vá em CpuBurn/App/CpuBurn.7z, dezzipe o 7z e excute o .exe


Para acessar baixe o arquivo do link abaixo:
https://drive.google.com/drive/u/0/folders/1C3DlBqe5dotF9pKX_mKzULzH_IUjEM2_

**1. Arquitetura Geral da Solução**

A aplicação foi desenvolvida em C# (.NET 8) utilizando WinForms como interface gráfica e ILGPU como backend para execução paralela na GPU. A solução possui dois módulos principais:

• CPU Burn — responsável por estressar núcleos individuais ou múltiplos da CPU.

• GPU Burn — responsável por estressar unidades de execução 3D/compute via ILGPU.
	
**2. Arquitetura do CPU Burn**

O módulo CPU Burn foi projetado para permitir estresse controlado por núcleo. Ele utiliza Tasks dedicadas, cada uma presa a um núcleo lógico específico, manipulando affinity de threads para garantir que cada carga executa unicamente no core selecionado.
A arquitetura se baseia em um loop dinâmico estruturado em ciclos de 100ms, onde parte do ciclo é 'busy' (realizando operações pesadas em float) e a outra parte é 'sleep', garantindo que o percentual configurado seja respeitado.
Componentes do CPU Burn:

• Seleção dinâmica de núcleos marcados pelo usuário.

• Busy-loop matemático com operações intensivas em ponto flutuante para aquecer ALUs e FPUs.

• Uso de CancellationToken para interrupção imediata e segura da carga.

• Escalonamento baseado em Stopwatch para respeitar o percentual configurado.



**3. Arquitetura do GPU Burn (ILGPU)**

O módulo GPU Burn foi totalmente reescrito utilizando ILGPU após limitações impostas pelo driver WDDM quando tentamos utilizar DirectX 12. ILGPU permite compilar kernels JIT para CUDA e OpenCL, garantindo ampla compatibilidade e desempenho.
Componentes do GPU Burn:

• Kernel BurnKernel executando laços intensivos com operações matemáticas.

• Alocação direta de buffers 1D na GPU, dimensionados conforme o número de multiprocessadores da placa.

• Dispatch contínuo do kernel dentro do ciclo de 100ms, sincronizando a GPU após cada execução.

• Utilização de Context + Accelerator para descoberta e execução em CUDA ou OpenCL automaticamente.


**4. Controle de Ciclo (CPU e GPU)**

Tanto CPU quanto GPU seguem o mesmo padrão arquitetural de execução baseado em ciclos:
1. busy-ms — período em que ocorre computação pesada.
2. sleep-ms — período de descanso para regular o percentual desejado.
Esse modelo garante previsibilidade e permite ao usuário definir com precisão a intensidade do estresse.
5. Interface Gráfica e Monitoramento
A interface gráfica exibe o consumo de CPU e GPU em tempo real. A leitura dos contadores GPU Engine foi adaptada para monitorar especificamente instâncias relacionadas ao processo atual, garantindo maior precisão ao interpretar o uso de 3D/Compute.
