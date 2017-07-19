package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * �^�����g�E�i���[�^�[�E�y�Ȍ_��\����(���[�p)�̌������ʃN���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/03/26 T.Hadate)<BR>
 * </P>
 * @author Takahiro Hadate
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class Contract4ReportResult extends AbstractServiceResult {
    /* =============================================================================================*/
    /** List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ� */
    private String _dummy;

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B���擾����.
     * @return String �_�~�[�v���p�e�B
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ݒ肷��.
     * @param dummy �_�~�[�v���p�e�B
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }
    /* =============================================================================================*/

    /** ���[�o�� �o�̓��X�g */
    private List<Contract4ReportVO> _contract4ReportVOList = null;

    /**
     * ���[�o�� �o�̓��X�g���擾����.
     * @return ���[�o�� �o�̓��X�g
     */
    public List<Contract4ReportVO> getContract4ReportVOList() {
        return _contract4ReportVOList;
    }

    /**
     * ���[�o�� �o�̓��X�g��ݒ肷��.
     * @param contract4ReportVOList ���[�o�� �o�̓��X�g
     */
    public void setContract4ReportVOList(List<Contract4ReportVO> contract4ReportVOList) {
        this._contract4ReportVOList = contract4ReportVOList;
    }


}
