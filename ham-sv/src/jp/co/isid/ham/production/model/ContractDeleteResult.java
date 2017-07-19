package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * �_����o�^��ʍ폜�{�^���������f�[�^�擾�̌��ʃN���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(20��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class ContractDeleteResult extends AbstractServiceResult{

    /* =============================================================================================*/
    /** List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ� */
    private String _dummy;

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B���擾���܂�
     * @return String �_�~�[�v���p�e�B
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ݒ肵�܂�
     * @param dummy �_�~�[�v���p�e�B
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }
    /* =============================================================================================*/
    /** �폜�{�^���������̃R���e���c�J�E���g�擾VO���X�g */
    private List<ContractDeleteCVO> _contractDeleteCVOList = null;

    /** �폜�{�^����������JASRAC�J�E���g�擾VO���X�g */
    private List<ContractDeleteJVO> _contractDeleteJVOList = null;

    /**
     * �R���e���c�J�E���gVO���X�g���擾����
     * @return �R�[�h�}�X�^VO���X�g
     */
    public List<ContractDeleteCVO> getContractDeleteCVOList() {
        return _contractDeleteCVOList;
    }

    /**
     * �R���e���c�J�E���gVO���X�g��ݒ肷��
     * @param mbj12CodeVOList �R�[�h�}�X�^VO���X�g
     */
    public void setContractDeleteCVOList(List<ContractDeleteCVO> contractDeleteCVOList) {
        this._contractDeleteCVOList = contractDeleteCVOList;
    }

    /**
     * JASRAC�J�E���gVO���X�g���擾����
     * @return �R�[�h�}�X�^VO���X�g
     */
    public List<ContractDeleteJVO> getContractDeleteJVOList() {
        return _contractDeleteJVOList;
    }

    /**
     * JASRAC�J�E���gVO���X�g��ݒ肷��
     * @param mbj12CodeVOList �R�[�h�}�X�^VO���X�g
     */
    public void setContractDeleteJVOList(List<ContractDeleteJVO> contractDeleteJVOList) {
        this._contractDeleteJVOList = contractDeleteJVOList;
    }

}
