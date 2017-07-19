package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;

public class ExcelOutSettingRegisterVO implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �o�͎Ԏ�pVO */
    private List<Mbj13CarOutCtrlVO> _carVO;

    /** �o�͔}�̗pVO */
    private List<Mbj14MediaOutCtrlVO> _mediaVO;

    /** �o�^�Ώۂ̒��[�R�[�h */
    private String _reportCd;

    /** �o�^�Ώۂ̃t�F�C�Y */
    private BigDecimal _phase;

    /**�S���R�[�h���̍X�V�����̍ŐV�l*/
    private Date _latestDate;

    /**�S���R�[�h���̍ŐV�X�V��*/
    private String _latestID;

    /**�S���R�[�h��*/
    private String _dataCnt;

    /** �_�~�[�v���p�e�B */
    private String _dummy;

    /**
     * �Ԏ�o�͂��擾���܂�
     * @return �Ԏ�o�͍���
     */
    public List<Mbj13CarOutCtrlVO> getMbj13CarOutCtrlVO() {
        return _carVO;
    }

    /**
     * �Ԏ�o�͂�ݒ肵�܂�
     * @param carVO
     */
    public void setMbj13CarOutCtrlVO(List<Mbj13CarOutCtrlVO> carVO) {
        _carVO = carVO;
    }

    /**
     * �}�̏o�͂��擾���܂�
     * @return
     */
    public List<Mbj14MediaOutCtrlVO> getMbj14MediaOutCtrlVO() {
        return _mediaVO;
    }

    /**
     * �}�̏o�͂�ݒ肵�܂�
     * @param mediaVO
     */
    public void setMbj14MediaOutCtrlVO(List<Mbj14MediaOutCtrlVO> mediaVO) {
        _mediaVO = mediaVO;
    }

    /**
     * ���[�R�[�h���擾���܂�
     * @return
     */
    public String getReportCd() {
        return _reportCd;
    }

    /**
     * ���[�R�[�h��ݒ肵�܂�
     * @param reportCd
     */
    public void setReportCd(String reportCd) {
        _reportCd = reportCd;
    }

    /**
     * �t�F�C�Y���擾���܂�
     * @return
     */
    @XmlElement(required = true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * �t�F�C�Y��ݒ肵�܂�
     * @param phase
     */
    public void setPhase(BigDecimal phase) {
        _phase = phase;
    }



    /**
     * _latestDate
     *
     * @return _latestDate
     */
    @XmlElement(required = true)
    public Date getLatestDate() {
        return _latestDate;
    }

    /**
     * _latestDate
     *
     * @param _latestDate �f�[�^�X�V����
     */
    public void setLatestDate(Date latestDate) {
        this._latestDate = latestDate;
    }

    /**
     * @return _latestID
     */
    public String getLatestID() {
        return _latestID;
    }
    /**
     * @param _latestID �Z�b�g���� _latestID
     */
    public void setLatestID(String latestID) {
        this._latestID = latestID;
    }

    /**
     * @return _dataCnt
     */
    public String getDataCnt() {
        return _dataCnt;
    }
    /**
     * @param _dataCnt �Z�b�g���� _dataCnt
     */
    public void setDataCnt(String dataCnt) {
        this._dataCnt = dataCnt;
    }

    /**
     * �_�~�[�v���p�e�B��Ԃ��܂�
     * @return
     */
    public String get_dummy() {
        return _dummy;
    }

    /**
     * �_�~�[�v���p�e�B��ݒ肷��
     * @param
     */
    public void set_dummy(String dummy) {
        _dummy = dummy;
    }

}
