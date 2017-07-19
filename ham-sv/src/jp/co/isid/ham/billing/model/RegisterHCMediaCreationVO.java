package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj04MediaMngEstimateDetailVO;
import jp.co.isid.ham.common.model.Tbj05EstimateItemVO;
import jp.co.isid.ham.common.model.Tbj06EstimateDetailVO;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HC�}�̔�쐬�o�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/4/23 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class RegisterHCMediaCreationVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �t�F�C�Y */
    private BigDecimal _phase = BigDecimal.valueOf(0);

    /** �N�� */
    private String _yearMonth = null;

    /** ���ώ�� */
    private String _estimateClass;

    /** �f�[�^�� */
    private int _dataCount = 0;

    /** �ŏI�X�V�� */
    private Date _latestUpdDate = null;

    /** �ŏI�X�V�� */
    private String _lagestUpdId = null;

    /** ���ψČ� �V�K */
    private List<Tbj05EstimateItemVO> _insEstimateListItem = null;

    /** ���ψČ� �X�V */
    private List<Tbj05EstimateItemVO> _updEstimateListItem = null;

    /** ���ψČ��Ǘ�NO(�폜�p) */
    private List<BigDecimal> _estseqno = null;

    /** �}�̔�ϖ��׊Ǘ� �폜 */
    private List<Tbj04MediaMngEstimateDetailVO> _delMediaMngEstDtl = null;

    /** ���ϖ��� �V�K */
    private List<Tbj06EstimateDetailVO> _insEstimateDetail = null;

    /** ���ϖ��� �X�V */
    private List<Tbj06EstimateDetailVO> _updEstimateDetail = null;

    /** �}�̔�ϖ��׊Ǘ� �V�K */
    private List<Tbj04MediaMngEstimateDetailVO> _insMediaMngEstDtl = null;


    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RegisterHCMediaCreationVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    @Override
    public Object newInstance() {
        return new RegisterHCEstimateCreationVO();
    }

    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param phase �t�F�C�Y
     */
    public void setPhase(BigDecimal phase) {
        _phase = phase;
    }

    /**
     * �N�����擾����
     *
     * @return �N��
     */
    public String getYearMonth() {
        return _yearMonth;
    }

    /**
     * �N����ݒ肷��
     *
     * @param yearMonth �N��
     */
    public void setYearMonth(String yearMonth) {
        _yearMonth = yearMonth;
    }

   /**
    * ���ώ�ʂ��擾���܂�
    *
    * @return ���ώ��
    */
   public String getEstimateClass() {
       return _estimateClass;
   }

   /**
    * ���ώ�ʂ�ݒ肵�܂�
    *
    * @param estimateClass ���ώ��
    */
   public void setEstimateClass(String estimateClass) {
       _estimateClass = estimateClass;
   }

    /**
     * �f�[�^�����擾����
     * @return
     */
    public int getDataCount() {
        return _dataCount;
    }

    /**
     * �f�[�^����ݒ肷��
     *
     * @param dataCount �f�[�^��
     */
    public void setDataCount(int dataCount) {
        _dataCount = dataCount;
    }

    /**
     * �ŏI�X�V�����擾����
     *
     * @return �ŏI�X�V��
     */
    @XmlElement(required = true, nillable = true)
    public Date getLatestUpdDate() {
        return _latestUpdDate;
    }

    /**
     * �ŏI�X�V����ݒ肷��
     *
     * @param latestUpdDate �ŏI�X�V��
     */
    public void setLatestUpdDate(Date latestUpdDate) {
        _latestUpdDate = latestUpdDate;
    }

    /**
     * �ŏI�X�V��ID���擾����
     *
     * @return �ŏI�X�V��ID
     */
    public String getLatestUpdId() {
        return _lagestUpdId;
    }

    /**
     * �ŏI�X�V��ID��ݒ肷��
     *
     * @param lagestUpdId �ŏI�X�V��ID
     */
    public void setLatestUpdId(String lagestUpdId) {
        _lagestUpdId = lagestUpdId;
    }

    /**
     * ���ψČ� �V�K���擾����
     *
     * @return ���ψČ� �V�K
     */
    public List<Tbj05EstimateItemVO> getInsEstimateListItem() {
        return _insEstimateListItem;
    }

    /**
     * ���ψČ� �V�K��ݒ肷��
     *
     * @param insEstimateListItem ���ψČ� �V�K
     */
    public void setInsEstimateListItem(List<Tbj05EstimateItemVO> insEstimateListItem) {
        _insEstimateListItem = insEstimateListItem;
    }

    /**
     * ���ψČ� �X�V���擾����
     *
     * @return ���ψČ� �X�V
     */
    public List<Tbj05EstimateItemVO> getUpdEstimateListItem() {
        return _updEstimateListItem;
    }

    /**
     * ���ψČ� �X�V��ݒ肷��
     *
     * @param updEstimateListItem ���ψČ� �X�V
     */
    public void setUpdEstimateListItem(List<Tbj05EstimateItemVO> updEstimateListItem) {
        _updEstimateListItem = updEstimateListItem;
    }

    /**
     * �폜�Ώۂ̌��ψČ��Ǘ�NO���擾����
     *
     * @return ���ψČ��Ǘ�NO
     */
    public List<BigDecimal> getEstseqno() {
        return _estseqno;
    }

    /**
     * �폜�Ώۂ̌��ψČ��Ǘ�NO��ݒ肷��
     *
     * @param estseqno ���ψČ��Ǘ�NO
     */
    public void setEstseqno(List<BigDecimal> estseqno) {
        this._estseqno = estseqno;
    }

    /**
     * �폜�Ώۂ̔}�̔�ϖ��׊Ǘ����擾����
     *
     * @return �}�̔�ϖ��׊Ǘ�
     */
    public List<Tbj04MediaMngEstimateDetailVO> getDelMediaMngEstDtl() {
        return _delMediaMngEstDtl;
    }

    /**
     * �폜�Ώۂ̔}�̔�ϖ��׊Ǘ���ݒ肷��
     *
     * @param mediaMngEstDtl �}�̔�ϖ��׊Ǘ�
     */
    public void setDelMediaMngEstDtl(List<Tbj04MediaMngEstimateDetailVO> delMediaMngEstDtl) {
        _delMediaMngEstDtl = delMediaMngEstDtl;
    }

    /**
     * �V�K�o�^�Ώۂ̌��ϖ��ׂ��擾����
     *
     * @return �V�K�o�^�Ώۂ̌��ϖ���
     */
    public List<Tbj06EstimateDetailVO> getInsEstimateDetail() {
        return _insEstimateDetail;
    }

    /**
     * �V�K�o�^�Ώۂ̌��ϖ��ׂ�ݒ肷��
     *
     * @param insEstimateDetail �V�K�o�^�Ώۂ̌��ϖ���
     */
    public void setInsEstimateDetail(List<Tbj06EstimateDetailVO> insEstimateDetail) {
        _insEstimateDetail = insEstimateDetail;
    }

    /**
     * �X�V�Ώۂ̌��ϖ��ׂ��擾����
     *
     * @return �X�V�Ώۂ̌��ϖ���
     */
    public List<Tbj06EstimateDetailVO> getUpdEstimateDetail() {
        return _updEstimateDetail;
    }

    /**
     * �X�V�Ώۂ̌��ϖ��ׂ�ݒ肷��
     *
     * @param updEstimateDetail �X�V�Ώۂ̌��ϖ���
     */
    public void setUpdEstimateDetail(List<Tbj06EstimateDetailVO> updEstimateDetail) {
        _updEstimateDetail = updEstimateDetail;
    }

    /**
     * �V�K�o�^�Ώۂ̔}�̔�ϖ��׊Ǘ����擾����
     *
     * @return �}�̔�ϖ��׊Ǘ�
     */
    public List<Tbj04MediaMngEstimateDetailVO> getInsMediaMngEstDtl() {
        return _insMediaMngEstDtl;
    }

    /**
     * �V�K�o�^�Ώۂ̔}�̔�ϖ��׊Ǘ���ݒ肷��
     *
     * @param mediaMngEstDtl �}�̔�ϖ��׊Ǘ�
     */
    public void setInsMediaMngEstDtl(List<Tbj04MediaMngEstimateDetailVO> insMediaMngEstDtl) {
        _insMediaMngEstDtl = insMediaMngEstDtl;
    }

}
