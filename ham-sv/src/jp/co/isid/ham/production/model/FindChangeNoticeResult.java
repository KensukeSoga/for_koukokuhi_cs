package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * CR�����@�ύX���e�ʒm�������s���̃f�[�^�擾�̌��ʃN���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/06/24 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindChangeNoticeResult extends AbstractServiceResult {

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

    /** �ύX���e�f�[�^VO���X�g */
    private List<FindChangeNoticeVO> _FindChangeNoticeVoList = null;

    /**
     * �ύX���e�f�[�^VO���X�g���擾����
     *
     * @return �ύX���e�f�[�^VO���X�g
     */
    public List<FindChangeNoticeVO> getFindChangeNoticeVoList() {
        return _FindChangeNoticeVoList;
    }

    /**
     * �ύX���e�f�[�^VO���X�g��ݒ肷��
     *
     * @param FindChangeNoticeVoList �ύX���e�f�[�^VO���X�g
     */
    public void setFindChangeNoticeVoList(List<FindChangeNoticeVO> FindChangeNoticeVoList) {
        this._FindChangeNoticeVoList = FindChangeNoticeVoList;
    }


}
