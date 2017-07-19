package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * CR�����@�������s���̃f�[�^�擾�̌��ʃN���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/30 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindCheckListTantoResult extends AbstractServiceResult {

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

    /** ������VO���X�g */
    private List<FindCheckListHattyuKykVO> _findCheckListHattyuKykVoList = null;

    /**
     * ������VO���X�g���擾����
     *
     * @return ������VO���X�g
     */
    public List<FindCheckListHattyuKykVO> getFindCheckListHattyuKykVoList() {
        return _findCheckListHattyuKykVoList;
    }

    /**
     * ������VO���X�g��ݒ肷��
     *
     * @param findCheckListHattyuKykVoList ������VO���X�g
     */
    public void setFindCheckListHattyuKykVoList(List<FindCheckListHattyuKykVO> findCheckListHattyuKykVoList) {
        this._findCheckListHattyuKykVoList = findCheckListHattyuKykVoList;
    }

    /** �c�Ɖ�v�S����VO���X�g */
    private List<FindCheckListTantoVO> _findCheckListTantoVoList = null;

    /**
     * �c�Ɖ�v�S����VO���X�g���擾����
     *
     * @return �c�Ɖ�v�S����VO���X�g
     */
    public List<FindCheckListTantoVO> getFindCheckListTantoVoList() {
        return _findCheckListTantoVoList;
    }

    /**
     * �c�Ɖ�v�S����VO���X�g��ݒ肷��
     *
     * @param findCheckListTantoVoList �c�Ɖ�v�S����VO���X�g
     */
    public void setFindCheckListTantoVoList(List<FindCheckListTantoVO> findCheckListTantoVoList) {
        this._findCheckListTantoVoList = findCheckListTantoVoList;
    }


}
