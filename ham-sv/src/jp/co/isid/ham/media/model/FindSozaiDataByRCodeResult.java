package jp.co.isid.ham.media.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj20SozaiKanriListVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* �f�ނ̏���ێ�����.
* </P>
* <P>
* <B>�C������</B><BR>
* �E�V�K�쐬(2013/02/05 HLC H.Watabe)<BR>
* </P>
* @author HLC H.Watabe
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindSozaiDataByRCodeResult extends AbstractServiceResult {

    /** �f�ފǗ��̃f�[�^��ێ����� */
    private List<Tbj20SozaiKanriListVO> _sozaivo;

    /**
     * �f�ފǗ��̃f�[�^���擾����
     * @return �f�ފǗ��f�[�^
     */
    public List<Tbj20SozaiKanriListVO> getSozaiKanriList() {
        return this._sozaivo;
    }

    /**
     * �f�ފǗ��̃f�[�^���Z�b�g����
     * @param sozaivo
     */
    public void setSozaiKanriList(List<Tbj20SozaiKanriListVO> sozaivo) {
        this._sozaivo = sozaivo;
    }

    /** List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ� */
    private String _dummy;

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ����擾���܂�
     * @return String �_�~�[�v���p�e�B
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ���ݒ肵�܂�
     * @param dummy �_�~�[�v���p�e�B
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }
}
