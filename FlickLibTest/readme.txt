using InputUtil;���K�v

�ő�360�����A360�x�D���Ȋp�x�Ɏn�_��ύX���ĕ��������t���b�N�������擾�ł���N���X

// ��{�I�Ȏg�p���@
�EFlickUtil.cs��Unity��GameObject�ɕt���܂�
�t���b�N���͂𗘗p����N���X����FlickUtil�N���X���擾���܂��B

�{�^�������A��������ł���ہA�������ۂ̔��������Ă��镔����
���ꂼ��OnButtonDown(),OnFlicking(),OnFlicked()�֐���FlickUtil�̃C���X�^���X����Ăяo���܂��B

��OnButtonDown()�����OnFlicked()���\�b�h�̓t���b�N�̎n�_�A�I�_�̍��W�����̂Ɏg�p���Ă���̂�
�K���Ăяo�����ƁB

OnFlicked()�̕Ԃ�l�ŕ��������ی��̔ԍ����擾�ł��܂��B(0�Ԃ̓^�b�v����j

�E�ی��̕����ɂ���
FlickUtil�N���X��quadrant�̒l��ύX���邱�Ƃŕ�������ی��̐�(3~360),
offsetAngle�ŏی��𕪊�����n�_�̊p�x�𒲐�(0~360)

�܂��AflickLength��ύX���邱�ƂŃt���b�N����Ƃ��鋗�����w��ł��܂��B

�EGizmo�ɂ�镪�������ی��̉���
DisplayGizmo.cs��Unity��GameObject�ɃA�^�b�`��FlickUtil�N���X��Inspector�ɃA�^�b�`���܂��B
DisplayGizmo�N���X��t����GameObject��I���������̂�UnityEditor��ŕ��������ی����m�F�ł��܂��B