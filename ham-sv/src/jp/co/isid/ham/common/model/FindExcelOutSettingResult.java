package jp.co.isid.ham.common.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* ���[�o�͐ݒ�̏���ێ�����.
* </P>
* <P>
* <B>�C������</B><BR>
* �E�V�K�쐬(2013/01/09 HLC H.Watabe)<BR>
* </P>
* @author HLC H.Watabe
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindExcelOutSettingResult extends AbstractServiceResult{

    /** �o�͔}�̂̏��擾 */
    private List<OutputMediaVO> _om;

    /** �o�͎Ԏ�̏��擾 */
    private List<OutputCarVO> _oc;

    /** �o�͂��Ȃ��}�̂̏��擾 */
    private List<Mbj03MediaVO> _media;

    /** �o�͂��Ȃ��Ԏ�̏��擾 */
    private List<Mbj05CarVO> _car;

    /**
     * �o�͔}��VO���擾���܂�
     * @return _om
     */
    public List<OutputMediaVO> getOutputMedia() {
        return _om;
    }

    /**
     * �o�͔}��VO��ݒ肵�܂�
     * @param _om �Z�b�g���� _om
     */
    public void setOutputMedia(List<OutputMediaVO> om) {
        _om = om;
    }

    /**
     * �o�͔}��VO���擾���܂�
     * @return _om
     */
    public List<OutputCarVO> getOutputCar() {
        return _oc;
    }

    /**
     * �o�͔}��VO��ݒ肵�܂�
     * @param _om �Z�b�g���� _om
     */
    public void setOutputCar(List<OutputCarVO> oc) {
        _oc = oc;
    }

    /**
     * �o�͂��Ȃ��}��VO���擾���܂�
     * @return
     */
    public List<Mbj03MediaVO> getMbj03Media() {
        return _media;
    }

    /**
     * �o�͂��Ȃ��}��VO��ݒ肵�܂�
     * @param media �Z�b�g���� _media
     */
    public void setMbj03Media(List<Mbj03MediaVO> media) {
        _media = media;
    }

    /**
     * �o�͂��Ȃ��Ԏ�VO���擾���܂�
     * @return
     */
    public List<Mbj05CarVO> getMbj05Car() {
        return _car;
    }

    /**
     * �o�͂��Ȃ��Ԏ�VO��ݒ肵�܂�
     * @param car
     */
    public void setMbj05Car(List<Mbj05CarVO> car) {
        _car = car;
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
