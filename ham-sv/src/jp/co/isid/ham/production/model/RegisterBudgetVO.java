package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.common.model.Tbj31CrBudgetPlanVO;
import jp.co.isid.ham.common.model.Tbj32CompurposeVO;

/**
 * <P>
 * CR�����@�o�^���s���̓o�^�f�[�^�ێ��N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/05 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class RegisterBudgetVO implements Serializable {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

    /** CR�\�Z�̍ő�^�C���X�^���v */
    private Date _maxDateTime = null;

    /** ��������VO */
    private FindBudgetDetailsCondition _findBudgetDetailsCondition = null;

    /** CR�\�ZVO���X�g */
    private List<Tbj31CrBudgetPlanVO> _tbj31CrBudgetPlanVoList = null;

    /** �ėp�R�����gVO���X�g */
    private Tbj32CompurposeVO _tbj32CompurposeVo = null;

    /**
     * CR�\�Z�̃^�C���X�^���v�ő�l���擾����
     *
     * @return CR�\�Z�̃^�C���X�^���v�ő�l
     */
    @XmlElement(required = true, nillable=true)
    public Date getMaxDateTime() {
        return _maxDateTime;
    }

    /**
     * CR�\�Z�̃^�C���X�^���v�ő�l��ݒ肷��
     *
     * @param maxDateTime CR�\�Z�̃^�C���X�^���v�ő�l
     */
    public void setMaxDateTime(Date maxDateTime) {
        this._maxDateTime = maxDateTime;
    }

    /**
     * �����������擾����
     *
     * @return ��������VO
     */
    public FindBudgetDetailsCondition getFindBudgetDetailsCondition() {
        return _findBudgetDetailsCondition;
    }

    /**
     * ����������ݒ肷��
     *
     * @param findBudgetDetailsCondition ��������VO
     */
    public void FindBudgetDetailsCondition(FindBudgetDetailsCondition findBudgetDetailsCondition) {
        this._findBudgetDetailsCondition = findBudgetDetailsCondition;
    }

    /**
     * CR�\�ZVO���X�g���擾����
     *
     * @return CR�\�ZVO���X�g
     */
    public List<Tbj31CrBudgetPlanVO> getTbj31CrBudgetPlanVoList() {
        return _tbj31CrBudgetPlanVoList;
    }

    /**
     * CR�\�Z���X�g��ݒ肷��
     *
     * @param tbj31CrBudgetPlanVoList CR�\�ZVO���X�g
     */
    public void setTbj31CrBudgetPlanVoList(List<Tbj31CrBudgetPlanVO> tbj31CrBudgetPlanVoList) {
        this._tbj31CrBudgetPlanVoList = tbj31CrBudgetPlanVoList;
    }

    /**
     * �ėp�R�����gVO���擾����
     *
     * @return �ėp�R�����gVO
     */
    public Tbj32CompurposeVO getTbj32CompurposeVo() {
        return _tbj32CompurposeVo;
    }

    /**
     * �ėp�R�����g��ݒ肷��
     *
     * @param tbj32CompurposeVo �ėp�R�����gVO
     */
    public void setTbj32CompurposeVo(Tbj32CompurposeVO tbj32CompurposeVo) {
        this._tbj32CompurposeVo = tbj32CompurposeVo;
    }

}
