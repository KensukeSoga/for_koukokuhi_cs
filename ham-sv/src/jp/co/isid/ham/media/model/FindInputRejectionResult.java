package jp.co.isid.ham.media.model;

import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.model.AbstractServiceResult;


/**
*
* <P>
* ���͋��ۃf�[�^�̏���ێ�����.
* </P>
* <P>
* <B>�C������</B><BR>
* �E�V�K�쐬(2012/12/18 FM H.izawa)<BR>
* </P>
* @author FM H.Izawa
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindInputRejectionResult extends AbstractServiceResult {

    /** ���͋��ۃf�[�^�̎擾by�}�̏󋵊Ǘ� */
    private List<FindInputRejectionVO> _rep;

    /** ���͋��ۃf�[�^�̎擾 by �c�ƍ�Ƒ䒠*/
    private List<FindInputRejectionVO> _rep1;
    /**
     * ���͋���VO���X�g���擾���܂�
     * @return _cam
     */
    public List<FindInputRejectionVO> getInputReject() {
        return _rep;
    }

    /**
     * ���͋���VO���X�g��ݒ肵�܂�
     * @param _cam �Z�b�g���� _cam
     */
    public void setInputReject(List<FindInputRejectionVO> rep) {
        _rep = rep;
    }

    /**
     * ���͋���VO���X�g���擾���܂�
     * @return _cam
     */
    public List<FindInputRejectionVO> getInputRejectByEigyo() {
        return _rep1;
    }

    /**
     * ���͋���VO���X�g��ݒ肵�܂�
     * @param _cam �Z�b�g���� _cam
     */
    public void setInputRejectByEigyo(List<FindInputRejectionVO> rep1) {
        _rep1 = rep1;
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
