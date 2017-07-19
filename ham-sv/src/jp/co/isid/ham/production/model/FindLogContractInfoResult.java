package jp.co.isid.ham.production.model;

import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * �_����X�V������ʁ@���s���̃f�[�^�擾�̌��ʃN���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/02/15 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindLogContractInfoResult extends AbstractServiceResult {

    /* ============================================================================= */
    /** List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ� */
    private String _dummy;

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B���擾���܂�
     *
     * @return String �_�~�[�v���p�e�B
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ݒ肵�܂�
     *
     * @param dummy �_�~�[�v���p�e�B
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }

    /* ============================================================================= */

    /** �X�V����\���f�[�^���OVO���X�g */
    private List<FindLogContractInfoVO> _findLogContractInfoVoList = null;

    /**
     * �X�V����\���f�[�^���OVO���X�g���擾����
     *
     * @return �X�V����\���f�[�^���OVO���X�g
     */
    public List<FindLogContractInfoVO> getFindLogContractInfoVoList() {
        return _findLogContractInfoVoList;
    }

    /**
     * �_����VO���X�g��ݒ肷��
     *
     * @param tbj10CrCarInfoVoList �_����VO���X�g
     */
    public void setFindLogContractInfoVoList(List<FindLogContractInfoVO> findLogContractInfoVoList) {
        this._findLogContractInfoVoList = findLogContractInfoVoList;
    }

    /* ============================================================================= */


}
